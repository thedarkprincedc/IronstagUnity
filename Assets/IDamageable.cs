using System.Collections;
using System.Collections.Generic;

public interface IDamageable<T>
{
    void Damage(T damageTaken);
}
