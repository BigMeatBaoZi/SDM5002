#include <Servo.h>

Servo myServo;
int servoPin = 6; // 舵机控制信号的输出端口

void setAngle (int angle, int duration)
{
  int pulseWidth = (angle * 50.0 / 9.0) + 1000; // 设置高电平时间长度(us)
  int pulseNum = duration / 20;                 // 设置脉冲个数
  
  for (int i = 0; i < pulseNum; i ++ ) {
    digitalWrite(servoPin, HIGH); // 设置输出高电平
    delayMicroseconds(pulseWidth); // 高电平延迟时间
    digitalWrite(servoPin, LOW);  // 设置回低电平
    delayMicroseconds(20000 - pulseWidth); // 低电平延迟时间(us)
  }
}

void setup()
{
  Serial.begin(9600); // 设置串口波特率
  myServo.attach(servoPin); // 设置Servo库的输出端口
  pinMode(servoPin, OUTPUT); // 设置端口工作模式为输出
}

void loop()
{
   if(Serial.available()){
    int a = Serial.parseInt();
    if(a == 1){
//        setAngle(30, 4000); // 设置以30的速度正向旋转4000ms// 控制180度舵机转到0度角位置
//        delay(3000); 
//        a=0;
       myServo.write(23);
       delay(100);
    }
    if(a == 2){
//        setAngle(90, 4000); // 设置以30的速度正向旋转4000ms// 控制180度舵机转到0度角位置
//        delay(3000); 
//        a=0;
        myServo.write(45);
        delay(100);
    }
    }
    else{
      Serial.println("a");
      }
//      myServo.write(90);
  }
    
