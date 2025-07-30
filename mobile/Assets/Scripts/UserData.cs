using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class UserData : MonoBehaviour
{
    public TMP_InputField loginInputField;
    public TMP_InputField passwordInputField;
    public TMP_InputField emailInputField;
    public TMP_InputField birthdateInputField;

    public TMP_Text loginValidationText;
    public TMP_Text passwordValidationText;
    public TMP_Text emailValidationText;
    public TMP_Text birthdateValidationText;

    private string login;
    private string password;
    private string email;
    private string birthdate;
    private Texture2D avatar;

    void Start()
    {
        if (emailInputField != null)
            emailInputField.onEndEdit.AddListener(ValidateEmail);

        if (loginInputField != null)
            loginInputField.onEndEdit.AddListener(ValidateLogin);

        if (passwordInputField != null)
            passwordInputField.onEndEdit.AddListener(ValidatePassword);

        if (birthdateInputField != null)
            birthdateInputField.onEndEdit.AddListener(ValidateBirthdate);
    }

    // Авторизация пользователя
    public void Login()
    {
        email = emailInputField.text;
        password = passwordInputField.text;
        Debug.Log($"1");

        if (
            email == null || password == null ||
            !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || !Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d).{8,}$")
        )
        {
            emailValidationText.text = "Неверный формат email";
            emailValidationText.color = Color.red;
            passwordValidationText.text = "Пароль: ≥6 символов, буквы и цифры";
            passwordValidationText.color = Color.red;
            return;
        }

        Debug.Log($"1");
        Debug.Log($"[Login] Email: {email}, Password: {password}");
        SceneManager.LoadScene(4);
    }

    // Валидация логина
    public void ValidateLogin(string input)
    {
        if (!string.IsNullOrWhiteSpace(input) && input.Length >= 3)
        {
            loginValidationText.text = "Логин корректный";
            loginValidationText.color = Color.green;
        }
        else
        {
            loginValidationText.text = "Логин должен быть не менее 3 символов";
            loginValidationText.color = Color.red;
        }
    }

    // Валидация почты
    public void ValidateEmail(string input)
    {
        if (Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            email = input;
        }
        else
        {
            emailValidationText.text = "Неверный формат email";
            emailValidationText.color = Color.red;
        }
    }

    // Валидация почты
    public void ValidatePassword(string input)
    {
        if (Regex.IsMatch(input, @"^(?=.*[A-Za-z])(?=.*\d).{8,}$"))
        {
            password = input;
        }
        else
        {
            passwordValidationText.text = "Пароль: ≥6 символов, буквы и цифры";
            passwordValidationText.color = Color.red;
        }
    }

    // Валидации даты рождения
    public void ValidateBirthdate(string input)
    {
        // Проверяем оба формата: 01.01.2000 и 2000-01-01
        if (Regex.IsMatch(input, @"^(0[1-9]|[12][0-9]|3[01])[.\-/](0[1-9]|1[0-2])[.\-/](19|20)\d\d$") ||
            Regex.IsMatch(input, @"^(19|20)\d\d[-/.](0[1-9]|1[0-2])[-/.](0[1-9]|[12][0-9]|3[01])$"))
        {
            birthdateValidationText.text = "Дата корректная";
            birthdateValidationText.color = Color.green;
        }
        else
        {
            birthdateValidationText.text = "Формат: 01.01.2000 или 2000-01-01";
            birthdateValidationText.color = Color.red;
        }
    }
}
