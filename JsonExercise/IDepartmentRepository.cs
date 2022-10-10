using JsonExercise;
using System;
using System.Collections.Generic;


namespace JsonExercise
{
    internal interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments(); //Stubbed out method
    }
}