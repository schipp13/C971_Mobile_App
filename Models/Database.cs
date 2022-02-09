using System;
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
            _database.CreateTableAsync<Assessment>().Wait();
            _database.CreateTableAsync<Instructor>().Wait();
            _database.CreateTableAsync<Term>().Wait();
        }

        public Task<int> PopulateTermsTable()
        {   Term term = new Term();
            term.Term_Name = "Term 1";
            term.Term_Start = DateTime.Now;
            term.Term_End = DateTime.Now.AddMonths(1);

            // Save a new Term.
            return _database.InsertAsync(term);

        }



        public Task<int> PopulateCourseTable()
        {
            Course course = new Course();
            course.Course_Name = "C971 Application Development Using C#";
            course.Course_Status = "Enrolled";
            course.Course_Start = DateTime.Now;
            course.Course_End = DateTime.Now.AddDays(10);
            course.Instructor_Name = "Saige";
            course.Instructor_Email = "schipp@wgu.edu";
            course.Instructor_Phone = "555-555-5555";
            course.Course_Description = "This is random text for a course description.";
            course.Term_Id = 1;

            // Save a new course.
            return _database.InsertAsync(course);

        }
        public Task<int> PopulateAssessmentsTable()
        {   
            Assessment assessment = new Assessment();
            assessment.Course_Id = 1;
            assessment.Assessment_Name = "Objective";
            assessment.Assessment_Type = "O";
            assessment.Assessment_Start = DateTime.Now.AddDays(2);
            assessment.Assessment_End = DateTime.Now.AddDays(5);

            // Save a new assessment.
            return _database.InsertAsync(assessment);
            
        }



public Task<List<Term>> GetTermsAsync()
        {
            // Get all Terms.
            return _database.Table<Term>().ToListAsync();
        }

        public Task<Term> GetTermAsync(int id)
        {
            // Get a specific term
            return _database.Table<Term>()
                            .Where(i => i.Term_Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Assessment>> GetAssessmentsAsync()
        {
            // Get all courses.
            return _database.Table<Assessment>().ToListAsync();
        }

        public Task<Assessment> GetAssesmentAsync(int id)
        {
            // Geta specific course.
            return _database.Table<Assessment>()
                            .Where(i => i.Course_Id == id)
                            .FirstOrDefaultAsync();
        }
        public Task<List<Assessment>> GetAssociatedAssessments(int id)
        {
            return _database.QueryAsync<Assessment>
                   ($"SELECT * FROM [Assessment] WHERE [Course_Id] = {id}");
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

        public Task<List<Course>> GetCurrentCourse(DateTime currentDate)
        {
            return _database.QueryAsync<Course>
                    ($"SELECT [Course_Name] FROM [Course] WHERE [Course_Start] = {currentDate}");
        }

        public Task<List<Course>> GetAssociatedCourseAsync(int id)
        {
            return _database.QueryAsync<Course>
                   ($"SELECT * FROM [Course] WHERE [Term_Id] = {id}");
        }
      

        public Task<Term> GetTermId(string name)
        {
            // Return the term id
            return _database.Table<Term>()
                             .Where(i => i.Term_Name == name)
                             .FirstOrDefaultAsync();

        }

        public Task<Instructor> GetInstructorAsync(int id)
        {
            // Geta specific Instructor.
            return _database.Table<Instructor>()
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

        public Task<int> SaveInstructorAsync(Instructor instructor)
        {
            if (instructor.Instructor_Id != 0)
            {
                // Update an existing instructor.
                return _database.UpdateAsync(instructor);
            }
            else
            {
                // Save a new course.
                return _database.InsertAsync(instructor);
            }
        }

        public Task<int> SaveTermAsync(Term term)
        {
            if (term.Term_Id != 0)
            {
                // Update an existing term.
                return _database.UpdateAsync(term);
            }
            else
            {
                // Save a new term.
                return _database.InsertAsync(term);
            }
        }

        public Task<int> SaveAssessmentAsync(Assessment assessment)
        {
            if (assessment.Assessment_Id != 0)
            {
                // Update an existing Assessment.
                return _database.UpdateAsync(assessment);
            }
            else
            {
                // Save a new assessment.
                return _database.InsertAsync(assessment);
            }
        }

        public Task<int> DeleteCourseAsync(Course course)
        {
            // Delete a course.
            return _database.DeleteAsync(course);
        }

        public Task<int> DeleteTermAsync(int id)
        {
            // Delete a course.
            return _database.Table<Term>()
                            .Where(i => i.Term_Id == id)
                            .DeleteAsync();
        }

        public Task<int> DeleteAssessmentAsync(Assessment assessment)
        {
            // Delete a assessment.
            return _database.DeleteAsync(assessment);
        }

   

    }
}