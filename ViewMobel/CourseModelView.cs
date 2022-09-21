namespace courseapp.ViewMobel
{
    public class CourseModelView
    {
       
        public int Id { get; set; }
      
        public string Name { get; set; }
      
        public DateTime CreationDate { get; set; }
        public string Descriptoin { get; set; }

        public IEnumerable <CategoryModelView> Category { get; set; }
       
       
    }
}
