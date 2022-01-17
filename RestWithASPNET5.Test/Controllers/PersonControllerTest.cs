using Microsoft.AspNetCore.Mvc;
using Moq;
using RestWithASPNET5.Business;
using RestWithASPNET5.Controllers;
using RestWithASPNET5.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestWithASPNET5.Test.Controllers
{
    public class PersonControllerTest
    {
        private MockRepository _mockRepository;
        Mock<IPersonBusiness> _mockPersonBusiness;
        Mock<IGenericBusiness<PersonVO>> _mockIGenericBusiness;

        public PersonControllerTest()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockPersonBusiness = _mockRepository.Create<IPersonBusiness>();
            _mockIGenericBusiness = _mockRepository.Create<IGenericBusiness<PersonVO>>();
        }

        private PersonController PersonController()
        {
            return new PersonController(_mockIGenericBusiness.Object, _mockPersonBusiness.Object);
        }

        [Fact]
        public void FindAllPersons()
        {
            List<PersonVO> persons = new List<PersonVO>()
            {
                new PersonVO {
                    Id = 1,
                    FirstName = "Alexin",
                    LastName = "Moreira",
                    Address = "Quixeramobim",
                    Gender = "Masculino"
                },
                new PersonVO {
                    Id = 2,
                    FirstName = "Alexin",
                    LastName = "Moreira",
                    Address = "Quixeramobim",
                    Gender = "Masculino"
                }
                    
            };

            var personController = PersonController();

            _mockIGenericBusiness.Setup(x => x.FindAll()).Returns(persons).Verifiable();

            ActionResult<List<PersonVO>> response = personController.Get();
            OkObjectResult result = (OkObjectResult)response.Result;

            List<PersonVO> data = (List<PersonVO>)result.Value;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(2, data.Count);

        }

        [Fact]
        public void ErroPut()
        {
            var personVO = new PersonVO()
            {
                Id = 1,
                FirstName = "Alexin",
                LastName = "Moreira",
                Address = "Quixeramobim",
                Gender = "Masculino"
            };

            PersonVO oldPerson = null;

            var personController = PersonController();

            _mockIGenericBusiness.Setup(a => a.Update(personVO)).Returns(oldPerson).Verifiable();

            IActionResult response = personController.Put(oldPerson);
            BadRequestObjectResult result = (BadRequestObjectResult)response;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Invalid person", result.Value);
        }

    }
}
