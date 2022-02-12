using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Models.DTO;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.Dto;
using Mass= MassTransit;
using MongoDB.Driver;
using FreeCourse.Shared.Messages;

namespace FreeCourse.Services.Catalog.Services
{
    public class CourseManager:ICourseService
    {
        private readonly IMongoCollection<Course> _courseMongoCollection;
        private readonly IMongoCollection<Category> _categoryMongoCollection;
        private readonly IMapper _mapper;
        ICategoryService _categoryService;
        private readonly Mass.IPublishEndpoint _publishEndpoint;
       

        public CourseManager(IMapper mapper, IDatabaseSettings settings, ICategoryService categoryService, Mass.IPublishEndpoint publishEndpoint)
        {
            var mongoClient = new MongoClient(settings.ConnectionStrings);
            var databaseName = mongoClient.GetDatabase(settings.DatabaseName);
            _courseMongoCollection = databaseName.GetCollection<Course>(settings.CourseCollectionName);
            _categoryMongoCollection = databaseName.GetCollection<Category>(settings.CategoryCollectionName);
            _mapper = mapper;
            _categoryService = categoryService;
            _publishEndpoint = publishEndpoint;
          
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseMongoCollection.Find(course => true).ToListAsync();
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryMongoCollection.Find<Category>(x => x.Id == course.CategoryId).FirstOrDefaultAsync();
                }
                
            }
            else
            {
                courses = new List<Course>();
            }
            return  Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses),200);
           
        }

       

        public async Task<Response<CourseDto>> GetByIdAsync(string courseId)
        {
            var course = await _courseMongoCollection.Find<Course>(x => x.Id == courseId).FirstOrDefaultAsync();
            if (course==null)
            {
                return  Response<CourseDto>.Fail("Course not found",404);
            }

            course.Category = await _categoryMongoCollection.Find<Category>(x => x.Id == course.CategoryId).FirstOrDefaultAsync();
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);




        }

       
        public async Task<Response<List<CourseDto>>> GetByUserIdAsync(string userId)
        {
            var courses =await _courseMongoCollection.Find<Course>(x => x.UserId == userId).ToListAsync();
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryMongoCollection.Find<Category>(x => x.Id == course.CategoryId).FirstOrDefaultAsync();
                }

            }
            else
            {
                courses = new List<Course>();
            }
            return Response<List<CourseDto>>.Success(_mapper.Map<List <CourseDto>> (courses), 200);
        }

        public async Task<Response<CourseDto>> AddAsync(CourseCreateDto courseCreateDto)
        {
            var newCourses = _mapper.Map<Course>(courseCreateDto);
            
            newCourses.CreatedTime=DateTime.Now;
            
            await _courseMongoCollection.InsertOneAsync(newCourses);

            return  Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourses),200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var updatedCourse = _mapper.Map<Course>(courseUpdateDto);
            var result =
                await _courseMongoCollection.FindOneAndReplaceAsync(x => x.Id == courseUpdateDto.Id, updatedCourse);
            if (result==null)
            {
                return  Response<NoContent>.Fail("course not found",404);
            }
            await _publishEndpoint.Publish<CourseNameChangedEvent>(new CourseNameChangedEvent { CourseId = courseUpdateDto.Id, UpdatedName = courseUpdateDto.Name });
            await _publishEndpoint.Publish<BasketCourseNameChangedEvent>(new BasketCourseNameChangedEvent { CourseId = courseUpdateDto.Id, UpdatedName = courseUpdateDto.Name });
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string courseId)
        {
            var result = await _courseMongoCollection.DeleteOneAsync(c => c.Id == courseId);
            if (result.DeletedCount>0)
            {
                return  Response<NoContent>.Success(204);
            }
            return  Response<NoContent>.Fail("course not found",404);
        }
    }
}
