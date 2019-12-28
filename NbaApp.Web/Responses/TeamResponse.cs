namespace NbaApp.Web.Responses
{
    public class TeamResponse
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }

        public TeamResponse(string id, string name, string nickName, string abbreviation, string conference, string division)
        {
            ID = id;
            Name = name;
            NickName = nickName;
            Abbreviation = abbreviation;
            Conference = conference;
            Division = division;
        }
    }
}
