using Xunit;
using PracticaGestionEstudiantes.Controllers;
using PracticaGestionEstudiantes.Models;
using PracticaGestionEstudiantes.Services;
using PracticaGestionEstudiantes.Test.Stubs;
using Moq;

namespace PracticaGestionEstudiantes.Test
{
    public class GetStudentStatus_HasReprobred_NotaMenor0
    {
        [Fact]
        public void GetStudentStatus_NotaMenor0_ReturnsReprobado_UsandoStub()
        {
            // Arrange
            EstudentController controller = new EstudentController(new StudentServiceStub());
            Estudiante estudiante = new Estudiante { CI = 123456, Nombre = "Javier", Nota = -1 };

            // Act
            var result = controller.GetStudentStatus(estudiante);

            // Assert
            Assert.Equal("Reprobado", result);
            Assert.Equal(-1, estudiante.Nota);
            Assert.Equal(123456, estudiante.CI);
            Assert.Equal("Javier", estudiante.Nombre);

            //-----------------------Otra forma con list<Estudiante>-------
            // // Arrange
            // EstudentController controller = new EstudentController(new StudentServiceStub());

            // // Act
            // var SelecEstudents = controller.GetAllStudents();
            // var result = controller.GetStudentStatus(SelecEstudents[3]);

            // // Assert
            // Assert.Equal("Reprobado", result);
            // Assert.Equal(123456, SelecEstudents[3].CI);
            // Assert.Equal("Javier", SelecEstudents[3].Nombre);
            // Assert.Equal(-1, SelecEstudents[3].Nota);

        }
        [Fact]
        public void GetStudentStatus_NotaMenor0_ReturnsReprobado_Moq()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            Estudiante estudiante = new Estudiante { CI = 123456, Nombre = "Javier", Nota = -1 };

            mockService.Setup(service => service.HasApproved(estudiante)).Returns(false);

            var controller = new EstudentController(mockService.Object);

            // Act
            var result = controller.GetStudentStatus(estudiante);

            // Assert
            Assert.Equal("Reprobado", result);
            Assert.Equal(123456, estudiante.CI);
            Assert.Equal("Javier", estudiante.Nombre);
            Assert.Equal(-1, estudiante.Nota);
        }

        // Para mejorar el Coverage
        [Fact]
        public void GetStudentStatus_NotaMenor0_ReturnsReprobado()
        {
            // Arrange
            // var studentService = new StudentService();
            // var controller = new EstudentController(studentService);
            EstudentController controller = new EstudentController(new StudentService());
            Estudiante estudiante = new Estudiante { CI = 123456, Nombre = "Javier", Nota = -1 };

            // Act
            var result = controller.GetStudentStatus(estudiante);

            // Assert
            Assert.Equal("Reprobado", result);
            Assert.Equal(-1, estudiante.Nota);
            Assert.Equal(123456, estudiante.CI);
            Assert.Equal("Javier", estudiante.Nombre);
        }
    }
}