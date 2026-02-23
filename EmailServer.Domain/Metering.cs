namespace EmailServer.Domain;

public class Metering
{
	private Metering(
		decimal hotWater,
		decimal coldWater,
		decimal electricity,
		DateTime? sendingDate)
	{
		HotWater = hotWater;
		ColdWater = coldWater;
		Electricity = electricity;
		SendingDate = sendingDate;
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
	public DateTime? SendingDate { get; private set; }

	public static Metering Create(
		decimal hotWater,
		decimal coldWater,
		decimal electricity) => new(hotWater, coldWater, electricity, null);

	public static Metering Restore(decimal hotWater,
									decimal coldWater,
									decimal electricity,
									DateTime sendingDate) => new(hotWater, coldWater, electricity, sendingDate);
}