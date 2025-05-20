using PracticaGestionEstudiantes.Models;
using PracticaGestionEstudiantes.Services;

namespace PracticaGestionEstudiantes.Test.Stubs
{
    public class StudentServiceStub : IStudentService
    {
        private List<Estudiante> _estudiantes;
        public StudentServiceStub()
        {
            _estudiantes = new List<Estudiante>()
            {
                new Estudiante { CI = 123, Nombre = "Juan", Nota = 60 },
                new Estudiante { CI = 456, Nombre = "Maria", Nota = 51 },
                new Estudiante { CI = 789, Nombre = "Pablo", Nota = 40 },
                new Estudiante { CI = 123456, Nombre = "Javier", Nota = -1 },
                new Estudiante { CI = 654, Nombre = "Amanda", Nota = 101 },
            };
        }
        public bool HasApproved(Estudiante estudiante)
        {
            // Cuando el estudiante siempre tiene una nota mayor o igual a 51
            //return true;
            //return estudiante.Nota >= 51;
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

        public List<Estudiante> GetAllStudents()
        {
            return _estudiantes;
        }
    }
}