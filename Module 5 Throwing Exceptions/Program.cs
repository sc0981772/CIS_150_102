namespace Module_5_Throwing_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter your username:");
                string username = Console.ReadLine();
                UserInputValidator.ValidateUsername(username);

                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();
                UserInputValidator.ValidatePassword(password);

                Console.WriteLine("User input is valid.");
            }
            catch (InvalidUsernameException ex)
            {
                Console.WriteLine($"Invalid username: {ex.Message}");
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine($"Invalid password: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
