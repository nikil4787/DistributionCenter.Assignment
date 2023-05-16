using System;
using DistributionCenter.Requests;
using FluentValidation;

namespace DistributionCenter.Validators
{
	public class ParcelValidator :AbstractValidator<Parcel>
	{
		public ParcelValidator()
		{
			RuleFor(X => X).NotNull();
            RuleFor(X => X.Receipient).NotNull();
            RuleFor(X => X.Sender).NotNull();
            RuleFor(X => X.Value).NotNull();
            RuleFor(X => X.Weight).NotNull();
        }
	}
}

