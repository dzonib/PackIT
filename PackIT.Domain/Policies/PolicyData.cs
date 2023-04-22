using PackIT.Domain.Consts;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Polisies;

public record PolicyData(TravelDays Days, Consts.Gender Gender, ValueObjects.Temperature Temperature, Localization Localization);