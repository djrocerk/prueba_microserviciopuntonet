namespace prueba_microservicio.Data
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Otras propiedades del campo

        public int StepId { get; set; }
        public Step Step { get; set; }
    }
}
