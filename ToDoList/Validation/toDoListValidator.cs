using FluentValidation;
using ToDoList.Models;


namespace ToDoList.Validation
{
    public class ToDoListValidator : AbstractValidator<ToDoListItems>
    {
        public ToDoListValidator()
        {
            //this.CascadeMode = CascadeMode.StopOnFirstFailure;

            //RuleFor(t => t.Task).NotNull().MaximumLength(100);
            //RuleFor(p => p.Priority).NotNull();
            //RuleFor(s => s.Status).NotNull();


        }

       
    }
}
