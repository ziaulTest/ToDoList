using FluentValidation;
using ToDoList.Models;

namespace ToDoList.Validation
{
    public class PartialToDoItemsValidator : AbstractValidator<PartialToDoItems>
    {
        public PartialToDoItemsValidator()
        {
            RuleFor(p => p.Priority).NotEmpty().WithMessage("Priority cannot be Null");
            RuleFor(T => T.Task).NotEmpty().Length(5, 250).WithMessage("cannot be less than 5 Characters");
        }
    }
}
