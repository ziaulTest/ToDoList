using FluentValidation;
using ToDoList.Models;


namespace ToDoList.Validation
{
    public class ToDoListValidator : AbstractValidator<ToDoListItems>
    {
        public ToDoListValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(p => p.Priority).NotEmpty().WithMessage("Priority cannot be Null");
            RuleFor(s => s.Status).NotNull().WithMessage("Status cannot be Null");
            RuleFor(T => T.Task).NotEmpty().Length(5, 250).WithMessage("cannot be less than 5 Characters");
        }
    }
}
