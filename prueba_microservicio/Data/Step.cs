namespace prueba_microservicio.Data
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Otras propiedades del paso

        public int FlowId { get; set; }
        public Flow Flow { get; set; }
    }
}
