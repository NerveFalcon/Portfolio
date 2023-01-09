using Microsoft.AspNetCore.Identity;

namespace Portfolio.Core.Data;

/// <summary> Общие данные пользователя </summary>
public class User : IdentityUser<Guid>
{
	/// <summary> Имя </summary>
	[ ProtectedPersonalData ]
	public string? FirstName { get; set; }

	/// <summary> Отчество </summary>
	[ ProtectedPersonalData ]
	public string? MiddleName { get; set; }

	/// <summary> Фамилия </summary>
	[ ProtectedPersonalData ]
	public string? LastName { get; set; }
}