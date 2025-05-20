using Xunit;
using PracticaGestionEstudiantes.Controllers;
using PracticaGestionEstudiantes.Models;
using PracticaGestionEstudiantes.Services;
using PracticaGestionEstudiantes.Test.Stubs;
using Moq;

namespace PracticaGestionEstudiantes.Test
{
    public class GetStudentStatus_HasReprobred_NotaMayor100()
    {
        [Fact]
        public void GetStudentStatus_NotaMayor100_ReturnsReprobado_UsandoStub()
        {
            // // Arrange
            // EstudentController controller = new EstudentController(new StudentServiceStub());
            // Estudiante estudiante = new Estudiante { CI = 654, Nombre = "Amanda", Nota = 101 };

            // // Act
            // var result = controller.GetStudentStatus(estudiante);

            // // Assert
            // Assert.Equal("Reprobado", result);
            // Assert.Equal(101, estudiante.Nota);
            // Assert.Equal(654, estudiante.CI);
            // Assert.Equal("Amanda", estudiante.Nombre);

            //---------------Otra forma con List<Estudiante>---------------
            //Arrange
            EstudentController controller = new EstudentController(new StudentServiceStub());


            // Act
            var SelecEstudents = controller.GetAllStudents();
            var result = controller.GetStudentStatus(SelecEstudents[4]);

            // Assert
            Assert.Equal("Reprobado", result);
            Assert.Equal(654, SelecEstudents[4].CI);
            Assert.Equal("Amanda", SelecEstudents[4].Nombre);
            Assert.Equal(101, SelecEstudents[4].Nota);
        }

        [Fact]
        public void GetStudentStatus_NotaMayor100_ReturnsReprobado_Moq()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            Estudiante estudiante = new Estudiante { CI = 654, Nombre = "Amanda", Nota = 101 };

            mockService.Setup(service => service.HasApproved(estudiante)).Returns(false);

            var controller = new EstudentController(mockService.Object);

            // Act
            var result = controller.GetStudentStatus(estudiante);

            // Assert
            Assert.Equal("Reprobado", result);

            Assert.Equal(654, estudiante.CI);
            Assert.Equal("Amanda", estudiante.Nombre);
            Assert.Equal(101, estudiante.Nota);
        }
        [Fact]
        public void GetStudentStatus_NotaMayor100_ReturnsReprobado()
        {
            // Arrange
            EstudentController controller = new EstudentController(new StudentService());
            Estudiante estudiante = new Estudiante { CI = 654, Nombre = "Amanda", Nota = 101 };

            // Act
            var result = controller.GetStudentStatus(estudiante);

            // Assert
            Assert.Equal("Reprobado", result);
            Assert.Equal(101, estudiante.Nota);
            Assert.Equal(654, estudiante.CI);
            Assert.Equal("Amanda", estudiante.Nombre);
        }
    }
}