using PracticaGestionEstudiantes.Models;
using PracticaGestionEstudiantes.Services;

namespace PracticaGestionEstudiantes.Controllers
{
    public class EstudentController 
    {
        private IStudentService _studentService;

        public EstudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public string GetStudentStatus(Estudiante estudiante)
        {
            // if (_studentService.HasAproved(estudiante))
            // {
            //     return "Aprobado";
            // }
            // else
            // {
            //     return "Reprobado";
            // }
            return _studentService.HasApproved(estudiante) ? "Aprobado" : "Reprobado";
        }
        public List<Estudiante> GetAllStudents()
        {
            return _studentService.GetAllStudents();
        }
    }
}