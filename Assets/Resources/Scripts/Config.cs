using UnityEngine;

namespace Config {
    public delegate void SimpleAction();
    public delegate void TargetedAction(Transform what);
    public delegate bool CanAction();
    public delegate bool StepMove(Vector3 vec);
    public delegate bool TargetMove(Entity target);
    public delegate bool SimpleMove();	
    public enum Postures{PRONE, STAND, JUMP};
    public enum Statuses{OK, STUN, DAMAGE, DESTROY, SEVER};
    public enum Phases{DEPLOY, ACTION, WEAPON, END};
}