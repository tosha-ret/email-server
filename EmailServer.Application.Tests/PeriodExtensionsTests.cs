using EmailServer.Application.PekMetering;
using FluentAssertions;

namespace EmailServer.Application.Tests;

public class PeriodExtensionsTests
{
    [Theory(DisplayName = "Получает ожидаемое название месяца по его номеру")]
    [InlineData(1, "январь")]
    [InlineData(3, "март")]
    [InlineData(8, "август")]
    public void Gets_expected_month_name_by_month_number(int monthNumber, string expectedMonthName)
    {
        var period = new Period(1, monthNumber);
        var actualMonthName = period.GetMonthName();

        actualMonthName.Should().Be(expectedMonthName);
    }
}