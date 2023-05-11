public class intensity FlickIntensity()
{
    float t0 = Time.time;
    float t = t0;
    WaitUntil wait = new WaitUntil(() => Time.time > t0 + t);
    yield return new WaitForSeconds(Random.Range(0.01f, 0.5f));

  while (true)
  {
      if (flickIntensity)
      {
          t0 = Time.time;
          float r = Random.Range(_baseIntensity - intensityRange, _baseIntensity + intensityRange);
          _light.intensity = r;
          t = Random.Range(intensityTimeMin, intensityTimeMax);
          yield return wait;
      }
      else yield return null;
  }
}