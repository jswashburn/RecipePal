using Microsoft.EntityFrameworkCore;
using RecipePal.Models;
using System;

namespace RecipePal.Data
{
    public static class ModelBuilderExtensions
    {
        static Random _rng = new Random();

        static int RandLikes => _rng.Next(0, 1000);
        static int RandDislikes => _rng.Next(0, 250);

        // Alter/Amend seed data here. EF will make the appropriate modifications to the DB.
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedCookbooks(modelBuilder);
            SeedComments(modelBuilder);
            SeedRecipes(modelBuilder);
            SeedNotes(modelBuilder);
        }

        static void SeedNotes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(
                new Note
                {
                    Id = 1,
                    RecipeId = 1,
                    Title = "Prep instructions",
                    Text = "Just cook it"
                },
                new Note
                {
                    Id = 2,
                    RecipeId = 2,
                    Title = "Prep instructions",
                    Text = "Yeah just figure it out"
                },
                new Note
                {
                    Id = 3,
                    RecipeId = 3,
                    Title = "Prep instructions",
                    Text = "Yeah okay yeah just cook it"
                },
                new Note
                {
                    Id = 4,
                    RecipeId = 4,
                    Title = "Prep instructions",
                    Text = "Cook it. Cook it good."
                },
                new Note // shrimp gumbo
                {
                    Id = 5,
                    RecipeId = 5,
                    Title = "Prep instructions",
                    Text = "Season generously"
                },
                new Note // fried chicken
                {
                    Id = 6,
                    RecipeId = 6,
                    Title = "Prep instructions",
                    Text = "Let stand 2-3 minutes"
                },
                new Note // health potion
                {
                    Id = 7,
                    RecipeId = 7,
                    Title = "Prep instructions",
                    Text = "Mix well"
                },
                new Note // rat poison
                {
                    Id = 8,
                    RecipeId = 8,
                    Title = "Prep instructions",
                    Text = "Add to cauldron and stir. All ingredients must still be alive."
                });
        }

        static void SeedRecipes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    CookbookId = 1,
                    Title = "Chicken Fried Steak",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Recipe
                {
                    Id = 2,
                    CookbookId = 1,
                    Title = "Pulled Pork",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Recipe
                {
                    Id = 3,
                    CookbookId = 2,
                    Title = "Christmas Cookies",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Recipe
                {
                    Id = 4,
                    CookbookId = 2,
                    Title = "Reindeer stew",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Recipe
                {
                    Id = 5,
                    CookbookId = 3,
                    Title = "Shrimp Gumbo",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Recipe
                {
                    Id = 6,
                    CookbookId = 3,
                    Title = "Fried Chicken",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Recipe
                {
                    Id = 7,
                    CookbookId = 4,
                    Title = "Health Potion",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Recipe
                {
                    Id = 8,
                    CookbookId = 4,
                    Title = "Rat poison",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                });
        }

        static void SeedComments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    CookbookId = 1,
                    UserId = 1,
                    Text = "This is awesome!",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Comment
                {
                    Id = 2,
                    CookbookId = 2,
                    UserId = 1,
                    Text = "This is kind-of awesome!",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Comment
                {
                    Id = 3,
                    CookbookId = 1,
                    UserId = 2,
                    Text = "This is gross!!",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Comment
                {
                    Id = 4,
                    CookbookId = 2,
                    UserId = 2,
                    Text = "This is not bad",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                });
        }

        static void SeedCookbooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cookbook>().HasData(
                new Cookbook
                {
                    Id = 1,
                    UserId = 1,
                    Title = "Southern Favorites",
                    CuisineType = "Southern",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Cookbook
                {
                    Id = 2,
                    UserId = 1,
                    Title = "Mrs. Claus Secret Recipes",
                    CuisineType = "Christmas",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Cookbook
                {
                    Id = 3,
                    UserId = 2,
                    Title = "Cajun Creations",
                    CuisineType = "Cajun",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                },
                new Cookbook
                {
                    Id = 4,
                    UserId = 2,
                    Title = "Potions and poisons",
                    CuisineType = "Fantasy",
                    Likes = RandLikes,
                    Dislikes = RandDislikes
                });
        }

        static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RPUser>().HasData(
                new RPUser
                {
                    Id = 1,
                    Username = "John J. Jingleheimer",
                    Password = "hash",
                    Email = "jjingleheimer@northpole.com"
                },
                new RPUser
                {
                    Id = 2,
                    Username = "wwishy",
                    Password = "P@55w0RD",
                    Email = "jsw@example.com"
                });
        }
    }
}
