namespace Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<address> address { get; set; }
        public virtual DbSet<claim> claim { get; set; }
        public virtual DbSet<commentaire> commentaire { get; set; }
        public virtual DbSet<contract> contract { get; set; }
        public virtual DbSet<endorsement> endorsement { get; set; }
        public virtual DbSet<forum> forum { get; set; }
        public virtual DbSet<insurance> insurance { get; set; }
        public virtual DbSet<insuredhistory> insuredhistory { get; set; }
        public virtual DbSet<messages> messages { get; set; }
        public virtual DbSet<notification> notification { get; set; }
        public virtual DbSet<policy> policy { get; set; }
        public virtual DbSet<reponse> reponse { get; set; }
        public virtual DbSet<report> report { get; set; }
        public virtual DbSet<statistics> statistics { get; set; }
        public virtual DbSet<t_todo> t_todo { get; set; }
        public virtual DbSet<topic> topic { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<vehicle> vehicle { get; set; }
        public virtual DbSet<vehiclesattt> vehiclesattt { get; set; }
        public virtual DbSet<vehicleswreck> vehicleswreck { get; set; }
        public virtual DbSet<user_claim> user_claim { get; set; }
        public virtual DbSet<user_endorsement> user_endorsement { get; set; }
        public virtual DbSet<user_insuredhistory> user_insuredhistory { get; set; }
        public virtual DbSet<user_policy> user_policy { get; set; }
        public virtual DbSet<user_statistics> user_statistics { get; set; }
        public virtual DbSet<user_user> user_user { get; set; }
        public virtual DbSet<user_vehiclesattt> user_vehiclesattt { get; set; }
        public virtual DbSet<user_vehicleswreck> user_vehicleswreck { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<address>()
                .Property(e => e.address1)
                .IsUnicode(false);

            modelBuilder.Entity<address>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<address>()
                .Property(e => e.government)
                .IsUnicode(false);

            modelBuilder.Entity<claim>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<claim>()
                .Property(e => e.cinInsured2)
                .IsUnicode(false);

            modelBuilder.Entity<claim>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<claim>()
                .Property(e => e.lang)
                .IsUnicode(false);

            modelBuilder.Entity<claim>()
                .Property(e => e.lat)
                .IsUnicode(false);

            modelBuilder.Entity<claim>()
                .Property(e => e.localisation)
                .IsUnicode(false);

            modelBuilder.Entity<claim>()
                .Property(e => e.namesAddressesPhonesWitnesses)
                .IsUnicode(false);

            modelBuilder.Entity<commentaire>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .HasMany(e => e.claim)
                .WithOptional(e => e.contract)
                .HasForeignKey(e => e.contract_id);

            modelBuilder.Entity<forum>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<insurance>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<insurance>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<insurance>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<messages>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<policy>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<policy>()
                .Property(e => e.wording)
                .IsUnicode(false);

            modelBuilder.Entity<policy>()
                .HasMany(e => e.commentaire)
                .WithOptional(e => e.policy)
                .HasForeignKey(e => e.policy_id);

            modelBuilder.Entity<reponse>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<report>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<report>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<t_todo>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.sujet)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.DTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.expertiseLevel)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.cin1)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.cin2)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.address)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.insured_id);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.immatriculation)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.marque)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.numchassis)
                .IsUnicode(false);

            modelBuilder.Entity<vehicleswreck>()
                .Property(e => e.couleur)
                .IsUnicode(false);

            modelBuilder.Entity<vehicleswreck>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<vehicleswreck>()
                .Property(e => e.modele)
                .IsUnicode(false);

            modelBuilder.Entity<vehicleswreck>()
                .Property(e => e.numchassis)
                .IsUnicode(false);
        }
    }
}
