using Autofac.Extras.Moq;
using AutoMapper;
using Business;
using Business.DTO;
using Business.Exceptions;
using DataAccess.Models;
using DataAccess.Repository;
using Moq;
using Platform.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using PlatformModel = Platform.Model;

namespace Service.Test.CodeLibrary.Business
{
    public class CashInBusinessTest
    {
        [Fact]
        public async Task AddCashIn_ShouldReturnOperationalResultWhenCashInProvidedAsync()
        {
            // Arrange

            using var mock = AutoMock.GetStrict();
            var cashInDto = new CashInDTO()
            {
                Amount = 100,
                Currency = "EUR",
                ExternalId = "1104",
                Payer = new Payer { PartyId = "442", PartyIdType = "Personal" },
                PayeeNote = "Complete",
                PayerMessage = "Thanks"
            };
            var cashIn = new CashIn();

            mock.Mock<IMapper>()
                .Setup(m => m.Map<CashIn>(It.IsAny<CashInDTO>()))
                .Returns(cashIn);

            mock.Mock<ImTellerRepository<CashIn>>()
               .Setup(m => m.Add(It.IsAny<CashIn>()))
               .Returns(true);

            mock.Mock<ImTellerRepository<CashIn>>()
               .Setup(m => m.SaveChangesAsync().Result)
               .Returns(true);

            mock.Mock<IDisbursement>()
               .Setup(m => m.Disburse(It.IsAny<PlatformModel.CashInPayload>()).Result)
               .Returns(true);

            mock.Mock<ImTellerRepository<CashIn>>()
              .Setup(m => m.Attached(It.IsAny<CashIn>()))
              .Returns(true);

            // Act

            var sut = mock.Create<CashInBusiness>();
            var actualResult = await sut.AddCashIn(cashInDto);

            //Assert

            Assert.NotNull(actualResult);
            Assert.IsType<OperationalResult<CashInDTO>>(actualResult);
            Assert.False(actualResult.Status);
        }

        [Fact]
        public void GetCashInDetialsToCashIn_ShouldReturnCashIn()
        {
            // Arrange

            var cashInDto = new CashInDTO() { Amount = 4000M, Payer = new Payer { PartyId = "419" } };

            // Act

            var actualResult = CashInBusiness.GetCashInDetialsToCashIn(cashInDto);

            //Assert

            Assert.NotNull(actualResult);
            Assert.IsType<CashIn>(actualResult);
        }

        [Fact]
        public void GetCashInDetialsToCashIn_ShouldThrowException_WhenAmoutAndPartyIdNotValid()
        {
            // Arrange

            var cashInDto = new CashInDTO();

            //Assert

            Assert.Throws<Exception>(() => CashInBusiness.GetCashInDetialsToCashIn(cashInDto));
        }

        [Fact]
        public async Task DeleteCashIn_ShouldReturnOperationalResultWhenCashInDeleted()
        {
            // Arrange

            using var mock = AutoMock.GetStrict();
            var cashInDto = new CashInDTO();
            var cashIn = new CashIn();
            var Id = 10101;

            mock.Mock<IMapper>()
                .Setup(m => m.Map<CashInDTO>(It.IsAny<CashIn>()))
                .Returns(cashInDto);

            mock.Mock<ImTellerRepository<CashIn>>()
               .Setup(m => m.DeleteAsync(It.IsAny<int>()))
               .ReturnsAsync(true);

            mock.Mock<ImTellerRepository<CashIn>>()
              .Setup(m => m.GetAsync(It.IsAny<int>()))
              .ReturnsAsync(cashIn);

            // Act

            var sut = mock.Create<CashInBusiness>();
            var actualResult = await sut.DeleteCashIn(Id);

            //Assert

            Assert.NotNull(actualResult);
            Assert.IsType<OperationalResult<CashInDTO>>(actualResult);
            Assert.True(actualResult.Status);
        }

        [Fact]
        public async Task GetAllCashIn_ShouldReturnAllCashIn()
        {
            // Arrange

            using var mock = AutoMock.GetStrict();
            var cashInDto = new CashInDTO();
            var cashIn = new CashIn();
            var cashIns = new List<CashIn> { cashIn, cashIn };
            var cashInsDto = new List<CashInDTO> { cashInDto, cashInDto };

            mock.Mock<IMapper>()
                .Setup(m => m.Map<IList<CashInDTO>>(It.IsAny<IEnumerable<CashIn>>()))
                .Returns(cashInsDto);

            mock.Mock<ImTellerRepository<CashIn>>()
              .Setup(m => m.GetAllAsync(It.IsAny<int>(), It.IsAny<int>()))
              .ReturnsAsync(cashIns);

            // Act

            var sut = mock.Create<CashInBusiness>();
            var actualResult = await sut.GetAllCashIn();

            //Assert

            Assert.NotNull(actualResult);
            Assert.IsType<OperationalResult<IList<CashInDTO>>>(actualResult);
            Assert.True(actualResult.Status);
            Assert.True(actualResult.Data.Any());
        }

        [Fact]
        public void GetCashIn_ShouldThrowException_WhenCashInIsNull()
        {
            // Arrange

            using var mock = AutoMock.GetStrict();
            var Id = 10101;

            mock.Mock<ImTellerRepository<CashIn>>()
              .Setup(m => m.GetAsync(It.IsAny<int>()))
              .ReturnsAsync(() => null);

            // Act

            var sut = mock.Create<CashInBusiness>();

            //Assert

            _ = Assert.ThrowsAsync<NotFoundException>(async () => await sut.GetCashIn(Id));
        }

        [Fact]
        public async Task UpdateCashIn_ShouldReturnUpdatedCashIn()
        {
            // Arrange

            using var mock = AutoMock.GetStrict();
            var cashInDto = new CashInDTO();
            var cashIn = new CashIn();

            mock.Mock<IMapper>()
                .Setup(m => m.Map<CashIn>(It.IsAny<CashInDTO>()))
                .Returns(cashIn);

            mock.Mock<ImTellerRepository<CashIn>>()
              .Setup(m => m.Update(It.IsAny<CashIn>()))
              .Returns(true);

            mock.Mock<IMapper>()
               .Setup(m => m.Map<CashInDTO>(It.IsAny<CashIn>()))
               .Returns(cashInDto);

            mock.Mock<ImTellerRepository<CashIn>>()
              .Setup(m => m.GetAsync(It.IsAny<int>()))
              .ReturnsAsync(cashIn);

            // Act

            var sut = mock.Create<CashInBusiness>();
            var actualResult = await sut.UpdateCashIn(cashInDto);

            //Assert

            Assert.NotNull(actualResult);
            Assert.IsType<OperationalResult<CashInDTO>>(actualResult);
            Assert.True(actualResult.Status);
        }
    }
}