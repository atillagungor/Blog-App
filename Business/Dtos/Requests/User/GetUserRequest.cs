﻿namespace Business.Dtos.Requests.User;

public class GetUserRequest
{
    public Guid? Id { get; set; }
	public string? Email { get; set; }
	public string? UserName { get; set; }
}