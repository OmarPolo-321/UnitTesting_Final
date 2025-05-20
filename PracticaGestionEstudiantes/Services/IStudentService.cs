using PracticaGestionEstudiantes.Models;

namespace PracticaGestionEstudiantes.Services
{ 
    public interface IStudentService
    {
        bool HasApproved(Estudiante estudiante);
        List<Estudiante> GetAllStudents();

    }
}