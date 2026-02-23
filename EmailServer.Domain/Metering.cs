namespace EmailServer.Domain;

public class Metering
{
	private Metering(
		decimal hotWater,
		decimal coldWater,
		decimal electricity,
		Period reportPeriod,
		DateTime? createDate)
	{
		HotWater = hotWater;
		ColdWater = coldWater;
		Electricity = electricity;
		ReportPeriod = reportPeriod;
		CreateDate = createDate;
	}

	/// <summary>
	/// Значение Горячая вода
	/// </summary>
	public decimal HotWater { get; private set; }

	/// <summary>
	/// Значение Холодная вода
	/// </summary>
	public decimal ColdWater { get; private set; }

	/// <summary>
	/// Значение Электричество
	/// </summary>
	public decimal Electricity { get; private set; }

	/// <summary>
	/// Дата отправки значений
	/// </summary>
	public DateTime? CreateDate { get; private set; }

	/// <summary>
	/// Отчётный период
	/// </summary>
	public Period ReportPeriod { get; private set; }

	public static Metering Create(
		decimal hotWater,
		decimal coldWater,
		decimal electricity,
		Period reportPeriod) => new(hotWater, coldWater, electricity, reportPeriod, null);

	public static Metering Restore(
		decimal hotWater,
		decimal coldWater,
		decimal electricity,
		Period reportPeriod,
		DateTime sendingDate) => new(hotWater, coldWater, electricity, reportPeriod, sendingDate);
}