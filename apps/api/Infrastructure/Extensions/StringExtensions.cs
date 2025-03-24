﻿using System.Security.Cryptography;
using System.Text;

namespace MovieStore.Api.Infrastructure.Extensions;

public static class StringExtensions
{
    public static string ComputeSha256Hash(this string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

        var builder = new StringBuilder();
        foreach (var b in bytes) builder.Append(b.ToString("x2"));

        return builder.ToString();
    }
}