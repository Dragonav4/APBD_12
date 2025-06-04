using System;
using System.Collections.Generic;

namespace APBD_s31722_12.Models;

public partial class Prescription
{
    public int IdPrescription { get; set; }

    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
}
