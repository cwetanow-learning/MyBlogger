using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace BlogSystem.Domain.Concrete.Abstract
{
    public abstract class BaseRepository
    {
        protected ApplicationDbContext context = new ApplicationDbContext();

        protected void SaveChanges()
        {
            try

            {

                this.context.SaveChanges();

            }

            catch (DbEntityValidationException ex)

            {

                // Retrieve the error messages as a list of strings.

                var errorMessages = ex.EntityValidationErrors

                        .SelectMany(x => x.ValidationErrors)

                        .Select(x => x.ErrorMessage);




                // Join the list to a single string.

                var fullErrorMessage = string.Join("; ", errorMessages);




                // Combine the original exception message with the new one.

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);




                // Throw a new DbEntityValidationException with the improved exception message.

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

            }

        }

        protected ApplicationUser GetUserById(string id)
        {
            var result = this.context.Users.Find(id);

            return result;
        }

        protected Post GetPostById(int id)
        {
            var result = this.context.Posts.Find(id);

            return result;
        }
    }
}
