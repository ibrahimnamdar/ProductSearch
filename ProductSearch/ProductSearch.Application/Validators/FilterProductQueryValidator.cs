using FluentValidation;
using ProductSearch.Application.Queries;
using ProductSearch.Domain.Entities;

namespace ProductSearch.Application.Validators
{
    public class FilterProductQueryValidator:AbstractValidator<FilterProductsQuery>
    {
        public FilterProductQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }
    }
}
