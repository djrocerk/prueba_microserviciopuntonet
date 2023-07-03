namespace prueba_microservicio.Data
{
    public class Flow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Otras propiedades del flujo

        public List<Step> Steps { get; set; }
    }
}
