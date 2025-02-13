using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module_5_Throwing_Exceptions;

namespace Module5Testing
{
    [TestClass]
    public class UserInputValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidUsernameException))]
        public void ValidateUsername_ShouldThrowException_WhenUsernameIsInvalid()
        {
            // Arrange
            string invalidUsername = "user";

            // Act
            UserInputValidator.ValidateUsername(invalidUsername);

            // Assert is handled by ExpectedException attribute
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void ValidatePassword_ShouldThrowException_WhenPasswordIsTooShort()
        {
            // Arrange
            string invalidPassword = "pass";

            // Act
            UserInputValidator.ValidatePassword(invalidPassword);

            // Assert is handled by ExpectedException attribute
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void ValidatePassword_ShouldThrowException_WhenPasswordLacksNumber()
        {
            // Arrange
            string invalidPassword = "password";

            // Act
            UserInputValidator.ValidatePassword(invalidPassword);

            // Assert is handled by ExpectedException attribute
        }

        [TestMethod]
        public void ValidateCredentials_ShouldNotThrowException_WhenCredentialsAreValid()
        {
            // Arrange
            string validUsername = "validUser";
            string validPassword = "password1";

            // Act & Assert
            try
            {
                UserInputValidator.ValidateUsername(validUsername);
                UserInputValidator.ValidatePassword(validPassword);
            }
            catch (Exception)
            {
                Assert.Fail("Expected no exception, but got one.");
            }
        }
    }
}
