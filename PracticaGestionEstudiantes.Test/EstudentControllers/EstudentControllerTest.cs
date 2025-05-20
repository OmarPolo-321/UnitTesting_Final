using Xunit;
using PracticaGestionEstudiantes.Controllers;
using PracticaGestionEstudiantes.Models;
using PracticaGestionEstudiantes.Services;
using PracticaGestionEstudiantes.Test.Stubs;
using Moq;

namespace PracticaGestionEstudiantes.Test.EstudentControllers
{
    public class EstudentControllerTest
    {
        [Fact]
        public void GetStudentStatus_HasApprobed()
        {
            // Arrange
            // var studentService = new StudentService();
            // var controller = new EstudentController(studentService);
            Estudiante estudiante = new Estudiante { CI = 123, Nombre = "Juan", Nota = 60 };

            EstudentController controller = new EstudentController(new StudentServiceStub());

            // Act
            //var SelecEstudents = controller.GetAllStudents();
            //var result = controller.GetStudentStatus(SelecEstudents[0]);
            var result = controller.GetStudentStatus(estudiante);

            // Assert
            // Assert.Equal("Reprobado", result);
            // Assert.Equal(123, SelecEstudents[0].CI);
            // Assert.Equal("Juan", SelecEstudents[0].Nombre);
            Assert.Equal("Aprobado", result);
            Assert.Equal(60, estudiante.Nota);
            Assert.Equal(123, estudiante.CI);
            Assert.Equal("Juan", estudiante.Nombre);
            
            //Assert.Equal("Reprobado", result);
        }
        [Fact]
        public void GetStudentStatus_HasNotApprobed()
        {
            // Arrange
            EstudentController controller = new EstudentController(new StudentServiceStub());
            var estudiante = new Estudiante { CI = 789, Nombre = "Pablo", Nota = 40 };

            // Act
            var result = controller.GetStudentStatus(estudiante);

            // Assert
            Assert.Equal("Reprobado", result);
            Assert.Equal(789, estudiante.CI);
            Assert.Equal("Pablo", estudiante.Nombre);
            Assert.Equal(40, estudiante.Nota);
        }
        [Fact]
        public void GetStudentStatus_HasApprobed_Moq()
        {
            // Arrange
            /*Usando la libreria moq*/
            var mockService = new Mock<IStudentService>();
            Estudiante estudiante = new Estudiante { CI = 123456, Nombre = "Maria", Nota = 60 };

            //mockService.Setup(service => service.HasApproved(It.IsAny<Estudiante>())).Returns(true);


            mockService.Setup(service => service.HasApproved(estudiante)).Returns(true);

            var controller = new EstudentController(mockService.Object);

            // Act
            var result = controller.GetStudentStatus(estudiante);

            // Assert
            Assert.Equal("Aprobado", result);
            //Assert.Equal("Reprobado", result);

            //Agrega una verificación para confirmar que el mock fue realmente llamado:
            mockService.Verify(service => service.HasApproved(It.IsAny<Estudiante>()), Times.Once);
            // Verifica que HasApproved fue llamado una vez
        }


        //Ejemplo de prueba de la función GetAllStudents
        [Fact]
        public void GetAllStudents()
        {
            // Arrange
            EstudentController controller = new EstudentController(new StudentServiceStub());

            // Act
            var result = controller.GetAllStudents();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Estudiante>>(result);
            Assert.Equal(60, result[0].Nota);
            Assert.Equal(51, result[1].Nota);
            Assert.Equal(5, result.Count);
        }
    }
}