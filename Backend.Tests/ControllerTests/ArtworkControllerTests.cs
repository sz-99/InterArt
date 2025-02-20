using FluentAssertions;
using InterArt.Controllers;
using InterArt.Models;
using InterArt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace Backend.Tests.ControllerTests
{
    public class ArtworkControllerTests
    {
        private ArtworkController _controller;
        private Mock<IArtworkService> _mockArtworkService;
        [SetUp]
        public void Setup()
        {
            _mockArtworkService = new Mock<IArtworkService>();
            _controller = new ArtworkController(_mockArtworkService.Object);
        }

        [Test]
        public void GetAllArtwork_Returns_Ok()
        {
            _mockArtworkService.Setup(s => s.LoadArtworks()).Returns(new List<Artwork>());

            var result = _controller.GetArtworks() as IActionResult;

            result.Should().BeOfType<OkObjectResult>();
        }
    }
}