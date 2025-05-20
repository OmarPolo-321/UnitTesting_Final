
using PracticaGestionEstudiantes.Models;


namespace PracticaGestionEstudiantes.Services
{
    public class StudentService : IStudentService
    {
        private List<Estudiante> estudiantes;

        public bool HasApproved(Estudiante estudiante)
        {
            if (estudiante.Nota >= 0 && estudiante.Nota <= 100)
            {
                //throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 100");
                if (estudiante.Nota >= 51)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 100");
                return false;
            }
        }

        public StudentService()
        {
            estudiantes = new List<Estudiante>();
        }
        public List<Estudiante> GetAllStudents()
        {
            return estudiantes;
        }

    }
}