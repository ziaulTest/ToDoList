using FluentValidation;
using ToDoList.Models;

namespace ToDoList.Validation
{
    public class PartialToDoItemsValidator : AbstractValidator<PartialToDoItems>
    {
        public PartialToDoItemsValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(p => p.Priority).NotEmpty().WithMessage("Priority cannot be Null");
            RuleFor(t => t.Task).NotEmpty().MaximumLength(250).WithMessage("cannot be greater than 250 chars");
            RuleFor(t => t.Task).NotEmpty().MinimumLength(5).WithMessage("cannot be less than 5 chars");
        }
    }
}
