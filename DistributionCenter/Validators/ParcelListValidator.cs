using System;
using DistributionCenter.Requests;
using FluentValidation;

namespace DistributionCenter.Validators
{
	public class ParcelListValidator : AbstractValidator<List<Parcel>>
	{
		public ParcelListValidator()
		{
			RuleForEach(x => x).SetValidator(new ParcelValidator());
		}
	}
}

