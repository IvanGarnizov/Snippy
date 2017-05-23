namespace Snippy.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Snippy.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Snippy.Data.SnippyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Snippy.Data.SnippyContext context)
        {
            if (context.Snippets.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));

            userManager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6
            };

            var admin = new User()
            {
                UserName = "admin",
                Email = "admin@snippy.softuni.com"
            };
            var someUser = new User()
            {
                UserName = "someUser",
                Email = "someUser@example.com"
            };
            var newUser = new User()
            {
                UserName = "newUser",
                Email = "new_user@gmail.com"
            };

            userManager.Create(admin, "adminPass123");
            userManager.Create(someUser, "someUserPass123");
            userManager.Create(newUser, "userPass123");

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole("Admin"));

            var adminUser = context.Users
                .First(u => u.UserName == "admin");

            userManager.AddToRole(adminUser.Id, "Admin");
            context.Languages.Add(new Language()
            {
                Name = "C#"
            });
            context.Languages.Add(new Language()
            {
                Name = "JavaScript"
            });
            context.Languages.Add(new Language()
            {
                Name = "Python"
            });
            context.Languages.Add(new Language()
            {
                Name = "CSS"
            });
            context.Languages.Add(new Language()
            {
                Name = "SQL"
            });
            context.Languages.Add(new Language()
            {
                Name = "PHP"
            });
            context.Labels.Add(new Label()
            {
                Text = "bug"
            });
            context.Labels.Add(new Label()
            {
                Text = "funny"
            });
            context.Labels.Add(new Label()
            {
                Text = "jquery"
            });
            context.Labels.Add(new Label()
            {
                Text = "mysql"
            });
            context.Labels.Add(new Label()
            {
                Text = "useful"
            });
            context.Labels.Add(new Label()
            {
                Text = "web"
            });
            context.Labels.Add(new Label()
            {
                Text = "geometry"
            });
            context.Labels.Add(new Label()
            {
                Text = "back-end"
            });
            context.Labels.Add(new Label()
            {
                Text = "front-end"
            });
            context.Labels.Add(new Label()
            {
                Text = "games"
            });
            context.SaveChanges();
            context.Snippets.Add(new Snippet()
            {
                Title = "Ternary Operator Madness",
                Description = "This is how you DO NOT user ternary operators in C#!",
                Code = "bool X = Glob.UserIsAdmin ? true : false;",
                CreationTime = new DateTime(2015, 10, 26, 17, 20, 33),
                Author = context.Users.First(u => u.UserName == "admin"),
                Language = context.Languages.First(l => l.Name == "C#"),
                Labels = new List<Label>()
                {
                    context.Labels.First(l => l.Text == "funny")
                }
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Points Around A Circle For GameObject Placement",
                Description = "Determine points around a circle which can be used to place elements around a central point",
                Code =
                @"private Vector3 DrawCircle(float centerX, float centerY, float radius, float totalPoints, float currentPoint)
{
    float ptRatio = currentPoint / totalPoints;
    float pointX = centerX + (Mathf.Cos(ptRatio * 2 * Mathf.PI)) * radius;
    float pointY = centerY + (Mathf.Sin(ptRatio * 2 * Mathf.PI)) * radius;
    Vector3 panelCenter = new Vector3(pointX, pointY, 0.0f);
    return panelCenter;
}",
                CreationTime = new DateTime(2015, 10, 26, 20, 15, 30),
                Author = context.Users.First(u => u.UserName == "admin"),
                Language = context.Languages.First(l => l.Name == "C#"),
                Labels = new List<Label>()
                {
                    context.Labels.First(l => l.Text == "geometry"),
                    context.Labels.First(l => l.Text == "games")
                }
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "forEach. How to break?",
                Description = "Array.prototype.forEach You can't break forEach. So use \"some\" or \"every\". Array.prototype.some some is pretty much the same as forEach but it break when the callback returns true.Array.prototype.every every is almost identical to some except it's expecting false to break the loop.",
                Code =
                @"var ary = [""JavaScript"", ""Java"", ""CoffeeScript"", ""TypeScript""];

ary.some(function (value, index, _ary) {
    console.log(index + "": "" + value);
    return value === ""CoffeeScript"";
});
// output:
// 0: JavaScript
// 1: Java
// 2: CoffeeScript

ary.every(function(value, index, _ary) {
    console.log(index + "": "" + value);
    return value.indexOf(""Script"") > -1;
});
// output:
// 0: JavaScript
// 1: Java",
                CreationTime = new DateTime(2015, 10, 27, 10, 53, 20),
                Author = context.Users.First(u => u.UserName == "newUser"),
                Language = context.Languages.First(l => l.Name == "JavaScript"),
                Labels = new List<Label>()
                {
                    context.Labels.First(l => l.Text == "jquery"),
                    context.Labels.First(l => l.Text == "useful"),
                    context.Labels.First(l => l.Text == "web"),
                    context.Labels.First(l => l.Text == "front-end")
                }
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Numbers only in an input field",
                Description = "Method allowing only numbers (positive / negative / with commas or decimal points) in a field",
                Code =
                @"$(""#input"").keypress(function(event){
    var charCode = (event.which) ? event.which : window.event.keyCode;
    if (charCode <= 13) { return true; }
    else {
        var keyChar = String.fromCharCode(charCode);
        var regex = new RegExp(""[0-9,.- ]"");
        return regex.test(keyChar);
    }
});",
                CreationTime = new DateTime(2015, 10, 28, 9, 0, 56),
                Author = context.Users.First(u => u.UserName == "someUser"),
                Language = context.Languages.First(l => l.Name == "JavaScript"),
                Labels = new List<Label>()
                {
                    context.Labels.First(l => l.Text == "web"),
                    context.Labels.First(l => l.Text == "front-end")
                }
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Create a link directly in an SQL query",
                Description = "That's how you create links - directly in the SQL!",
                Code =
                @"SELECT DISTINCT
        b.Id,
        concat('<button type=""button"" onclick=""DeleteContact(', cast(b.Id as char), ')"">Delete...</button>') as lnkDelete
FROM tblContact b
WHERE ....",
                CreationTime = new DateTime(2015, 10, 30, 11, 20, 0),
                Author = context.Users.First(u => u.UserName == "admin"),
                Language = context.Languages.First(l => l.Name == "SQL"),
                Labels = new List<Label>()
                {
                    context.Labels.First(l => l.Text == "bug"),
                    context.Labels.First(l => l.Text == "funny"),
                    context.Labels.First(l => l.Text == "mysql")
                }
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Reverse a String",
                Description = "Almost not worth having a function for...",
                Code =
                @"def reverseString(s):
	Reverses a string given to it.
	return s[::-1]",
                CreationTime = new DateTime(2015, 10, 26, 9, 35, 13),
                Author = context.Users.First(u => u.UserName == "admin"),
                Language = context.Languages.First(l => l.Name == "Python"),
                Labels = new List<Label>()
                {
                    context.Labels.First(l => l.Text == "useful")
                }
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Pure CSS Text Gradients",
                Description = "This code describes how to create text gradients using only pure CSS",
                Code = 
                @"/* CSS text gradients */
h2[data-text] {
    position: relative;
}
h2[data-text]::after {
    content: attr(data-text);
    z-index: 10;
    color: #e3e3e3;
    position: absolute;
    top: 0;
    left: 0;
    -webkit- mask-image: -webkit- gradient(linear, left top, left bottom, from(rgba(0,0,0,0)), color-stop(50%, rgba(0,0,0,1)), to(rgba(0,0,0,0)));",
                CreationTime = new DateTime(2015, 10, 22, 19, 26, 42),
                Author = context.Users.First(u => u.UserName == "someUser"),
                Language = context.Languages.First(l => l.Name == "CSS"),
                Labels = new List<Label>()
                {
                    context.Labels.First(l => l.Text == "web"),
                    context.Labels.First(l => l.Text == "front-end")
                }
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Check for a Boolean value in JS",
                Description = "How to check a Boolean value - the wrong but funny way :D",
                Code = 
                @"var b = true;

if (b.toString().length < 5) {
    //...
}",
                CreationTime = new DateTime(2015, 10, 22, 5, 30, 4),
                Author = context.Users.First(u => u.UserName == "admin"),
                Language = context.Languages.First(l => l.Name == "JavaScript"),
                Labels = new List<Label>()
                {
                    context.Labels.First(l => l.Text == "funny")
                }
            });
            context.SaveChanges();
            context.Comments.Add(new Comment()
            {
                Content = "Now that's really funny! I like it!",
                CreationTime = new DateTime(2015, 10, 30, 11, 50, 38),
                Author = context.Users.First(u => u.UserName == "admin"),
                Snippet = context.Snippets.First(s => s.Title == "Ternary Operator Madness")
            });
            context.Comments.Add(new Comment()
            {
                Content = "Here, have my comment!",
                CreationTime = new DateTime(2015, 11, 1, 15, 52, 42),
                Author = context.Users.First(u => u.UserName == "newUser"),
                Snippet = context.Snippets.First(s => s.Title == "Ternary Operator Madness")
            });
            context.Comments.Add(new Comment()
            {
                Content = "I didn't manage to comment first :(",
                CreationTime = new DateTime(2015, 11, 2, 5, 30, 20),
                Author = context.Users.First(u => u.UserName == "someUser"),
                Snippet = context.Snippets.First(s => s.Title == "Ternary Operator Madness")
            });
            context.Comments.Add(new Comment()
            {
                Content = "That's why I love Python - everything is so simple!",
                CreationTime = new DateTime(2015, 10, 27, 15, 28, 14),
                Author = context.Users.First(u => u.UserName == "newUser"),
                Snippet = context.Snippets.First(s => s.Title == "Reverse a String")
            });
            context.Comments.Add(new Comment()
            {
                Content = "I have always had problems with Geometry in school. Thanks to you I can now do this without ever having to learn this damn subject",
                CreationTime = new DateTime(2015, 10, 29, 15, 8, 42),
                Author = context.Users.First(u => u.UserName == "someUser"),
                Snippet = context.Snippets.First(s => s.Title == "Points Around A Circle For GameObject Placement")
            });
            context.Comments.Add(new Comment()
            {
                Content = "Thank you. However, I think there must be a simpler way to do this. I can't figure it out now, but I'll post it when I 'm ready.",
                CreationTime = new DateTime(2015, 11, 3, 12, 56, 20),
                Author = context.Users.First(u => u.UserName == "admin"),
                Snippet = context.Snippets.First(s => s.Title == "Numbers only in an input field")
            });
            context.SaveChanges();
        }
    }
}
