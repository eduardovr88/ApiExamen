﻿using ApiExamen.Models;
using System.ComponentModel.DataAnnotations.Schema;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Chapters { get; set; }

    public int Pages { get; set; }

    public decimal Price { get; set; }
    [ForeignKey("AuthorId")]
    public int AuthorId { get; set; }

    public virtual Author Author { get; set; }
}

