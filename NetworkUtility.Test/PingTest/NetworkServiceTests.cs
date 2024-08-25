using FluentAssertions;
using FluentAssertions.Extensions;
using Moq;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;

namespace NetworkUtility.Test.PingTest
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;
        private readonly Mock<IDns> _dns;

        public NetworkServiceTests()
        {
            //Dependencies
            _dns = new Mock<IDns>();

            //SUT
            _pingService = new NetworkService(_dns.Object);
        }



        //test with no parameters
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - variables, classes ,mocks
            _dns.Setup(d => d.SendDNS()).Returns(true);

            //Act - Excute the function
            var result = _pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }
        //used to define a test method that can take multiple sets of inputs
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]

        public void NetworkService_PingTimeout_ReturnInt(int i, int j, int expected)
        {

            //Arrange


            //Act
            var result = _pingService.PingTimeout(i, j);


            //Assert
            Assert.Equal(1, result);

            //using Fluent assert 
            //result.Should().Be(expected);
            //result.Should().BePositive();
            //result.Should().BeGreaterThanOrEqualTo(2);

        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //Arrange - variables, classes ,mocks


            //Act - Excute the function
            var result = _pingService.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));



        }

        [Fact]

        public void NetworkService_GetPingOptions_ReturnObject()
        {

            //Arrange
            var expectedResults = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1,
            };

            //Act
            var result = _pingService.GetPingOptions();


            //Assert : When comparing objects or reference types, don't use Be
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expectedResults);
            result.Ttl.Should().Be(1);

        }

        [Fact]

        public void NetworkService_MostRecentPings_ReturnObject()
        {

            //Arrange
            var expectedResults = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1,
            };

            //Act
            var result = _pingService.MostRecentPings();


            //Assert : When comparing objects or reference types, don't use Be
            result.Should().ContainEquivalentOf(expectedResults);
            result.Should().Contain(q => q.DontFragment == true);


        }


    }
}
