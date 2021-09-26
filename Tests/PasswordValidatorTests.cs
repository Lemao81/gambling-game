using System.Linq;
using GamblingGame.Domain.Services;
using Xunit;

namespace Tests
{
    public class PasswordValidatorTests
    {
        private readonly PasswordValidator _classUnderTest;

        public PasswordValidatorTests()
        {
            _classUnderTest = new PasswordValidator();
        }

        [Fact]
        public void Validate_ValidInput_NoErrorsReturned()
        {
            // Arrange
            const string password = "abcDefg!";

            // Act
            var errors = _classUnderTest.Validate(password);

            // Assert
            Assert.Equal(0, errors.Count);
        }

        [Fact]
        public void Validate_InvalidLength_ErrorReturned()
        {
            // Arrange
            const string password = "cDfg!";

            // Act
            var errors = _classUnderTest.Validate(password);

            // Assert
            Assert.Equal(1, errors.Count);
            Assert.Contains("at least 6 characters", errors.First());
        }

        [Fact]
        public void Validate_InvalidNoUpperCase_ErrorReturned()
        {
            // Arrange
            const string password = "abcdefg!";

            // Act
            var errors = _classUnderTest.Validate(password);

            // Assert
            Assert.Equal(1, errors.Count);
            Assert.Contains("an upper letter", errors.First());
        }

        [Fact]
        public void Validate_InvalidNoSpecialCharacter_ErrorReturned()
        {
            // Arrange
            const string password = "abcDefgw";

            // Act
            var errors = _classUnderTest.Validate(password);

            // Assert
            Assert.Equal(1, errors.Count);
            Assert.Contains("a special character", errors.First());
        }
    }
}
