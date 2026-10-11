namespace SbankAPI.Domain.Entities;

public class Tbl_User
{
    public long UserID { get; private set; }

    public string UName { get; private set; } = string.Empty;

    public string UEmail { get; private set; } = string.Empty;

    public string UMobile { get; private set; } = string.Empty;

    // Store a password hash, never a plain-text password.
    public string UPassword { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public bool IsActive { get; private set; } = true;

    private Tbl_User() { } // For EF Core

    public Tbl_User(
        string name,
        string email,
        string mobile,
        string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.");

        if (name.Trim().Length > 100)
            throw new ArgumentException("Name cannot exceed 100 characters.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");

        if (email.Trim().Length > 100)
            throw new ArgumentException("Email cannot exceed 100 characters.");

        if (!System.Net.Mail.MailAddress.TryCreate(email.Trim(), out var address)
            || !string.Equals(address.Address, email.Trim(),
                StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Invalid email address.");

        if (string.IsNullOrWhiteSpace(mobile) ||
            !System.Text.RegularExpressions.Regex.IsMatch(
                mobile, @"^\d{10,12}$"))
            throw new ArgumentException(
                "Mobile number must be 10-12 digits.");

        if (string.IsNullOrWhiteSpace(passwordHash) ||
            passwordHash.Length > 256)
            throw new ArgumentException("Invalid password hash.");

        UName = name.Trim();
        UEmail = email.Trim();
        UMobile = mobile;
        UPassword = passwordHash;
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public void UpdateProfile(string name, string mobile)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Trim().Length > 100)
            throw new ArgumentException("Invalid name.");

        if (string.IsNullOrWhiteSpace(mobile) ||
            !System.Text.RegularExpressions.Regex.IsMatch(
                mobile, @"^\d{10,12}$"))
            throw new ArgumentException("Invalid mobile number.");

        UName = name.Trim();
        UMobile = mobile;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
}