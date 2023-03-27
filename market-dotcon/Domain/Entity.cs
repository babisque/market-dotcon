using Flunt.Notifications;

namespace market_dotcon.Domain;

public abstract class Entity : Notifiable<Notification>
{
    public int Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string EditedBy { get; set; }
    public DateTime EditedOn { get; set; }
}
