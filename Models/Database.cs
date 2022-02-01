using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;


namespace  c971_MobileApplication.Models
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<Course>().Wait();
        }

        public Task<List<Course>> GetCoursesAsync()
        {
            // Get all courses.
            return _database.Table<Course>().ToListAsync();
        }

        public Task<Course> GetCourseAsync(int id)
        {
            // Geta specific course.
            return _database.Table<Course>()
                            .Where(i => i.Course_Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCourseAsync(Course course)
        {
            if (course.Course_Id != 0)
            {
                // Update an existing course.
                return _database.UpdateAsync(course);
            }
            else
            {
                // Save a new course.
                return _database.InsertAsync(course);
            }
        }

        public Task<int> DeleteNoteAsync(Course course)
        {
            // Delete a course.

            return _database.DeleteAsync(course);
        }

    }
}