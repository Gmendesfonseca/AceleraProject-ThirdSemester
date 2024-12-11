//using InnerAPI.Services;

//namespace InnerAPI.Controllers
//{
//    public static class CourseController
//    {
//        public static RouteGroupBuilder MapCourseEndpoint(this WebApplication app, SharedService sharedServices)
//        {
//            ChatServices courseServices = new ChatServices(sharedServices);
//            var group = app.MapGroup("course").WithParameterValidation();

//            // GET /course/{id}
//            group.MapGet("/{id}", (int id) =>
//            {
//                return Results.Ok(courseServices.GetCourses().FirstOrDefault(s => s.Id == id));
//            });

//            // POST /course/register
//            group.MapPost("/register", (RegisterCourseDto newCourse) =>
//            {
//                Course course = courseServices.Register(newCourse);

//                return Results.Created($"/course/{course.Id}", course);
//            });

//            // PUT /course/{id}
//            group.MapPut("/{id}", (int id, UpdateCourseDto updatedCourse) =>
//            {
//                var result = courseServices.Update(id, updatedCourse);
//                if (result == null)
//                {
//                    return Results.NotFound();
//                }
//                return Results.Ok(result);
//            });

//            // DELETE /course/{id}
//            group.MapDelete("/{id}", (int id) =>
//            {
//                bool deleted = courseServices.Delete(id);
//                if (!deleted)
//                {
//                    return Results.NotFound();
//                }
//                return Results.NoContent();
//            });

//            return group;
//        }
//    }
//}
