const int trigPin = 8;
const int echoPin = 7;

const float SOUND_SPEED_FACTOR = 58.2;

void setup() {
  Serial.begin(9600);       //波特率
  pinMode(trigPin, OUTPUT); // 输出
  pinMode(echoPin, INPUT);  // 输入
  digitalWrite(trigPin, LOW);
}

void loop() {
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  long duration = pulseIn(echoPin, HIGH);
  float distance = duration / SOUND_SPEED_FACTOR;
  //打印结果到串口监视器
  Serial.print("距离: ");
  Serial.print(distance);
  Serial.println(" cm");
  delay(500);/*时隔500毫秒重新测量*/
}
