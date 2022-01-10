#include <msp430g2553.h>

//Defines
#define BUTTON BIT7

//Globals
int receivedVal = 0;
int adc_val = 0;

int Timer_50ms_Counter = 0;
int Timer_100ms_Counter = 0;
int Timer_1s_Counter = 0;
int Timer_2s_Counter = 0;
int Timer_3s_Counter = 0;

int Timer_50ms_flag = 0;
int Timer_100ms_flag = 0;
int Timer_1s_flag = 0;
int Timer_2s_flag = 0;
int Timer_3s_flag = 0;

int R_Value = 0;
int G_Value = 0;
int B_Value = 0;

//Function Prototypes
__interrupt void ADC10_ISR(void);
__interrupt void Port_1(void);
interrupt void USCI0RX_ISR(void);
void Mode1_Control(void);
void Mode2_Control(void);
void Mode3_Control(void);
void Mode4_Control(void);
void Task_manager(void);

void Timer_delay_1s(void);
void Timer_delay_2s(void);
void Timer_delay_3s(void);
void Timer_delay_100ms(void);
void Timer_delay_50ms(void);

int main(void)
{

    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

//
//CLOCK SELECT SETTINGS
//
    DCOCTL = 0;
    BCSCTL1 = CALBC1_1MHZ;          // Clock saatini 1 MHZ ayarlamak
    DCOCTL = CALDCO_1MHZ;
    __delay_cycles(100000);

    P1DIR |= BIT0;

    //
    //PWM PINS OUTPUT SETTINGS
    //
    P1DIR |= BIT6;     // P1.6 Pwm output       Red
    P1SEL |= BIT6;

    P2DIR |= BIT1;      // P2.1  Pwm output       Green
    P2SEL |= BIT1;

    P2DIR |= BIT5;      // P2.5  Pwm output       Blue
    P2SEL |= BIT5;
    //
    //TIMER0 - TIMER1  SETINGS   && PWM OUT SETTINGS
    //
    TA0CTL = TASSEL_2 + MC_1 + TAIE; // Timer SMCLK Modo UP
    TA0CCTL1 = OUTMOD_7;    // PWM1 SETS - RESET/SET
    TA0CCR0 = 255;          // Timer A1 Period
    TACCTL0 |= CCIE;
    TA0CTL &= ~TAIFG;

    TA1CTL = TASSEL_2 + MC_1; // Timer SMCLK Modo UP
    TA1CCTL1 = OUTMOD_7;    // PWM2 SETS - RESET/SET
    TA1CCTL2 = OUTMOD_7;    // PWM3 SETS - RESET/SET
    TA1CCR0 = 255;          // Timer A1 Period

    TA0CCR1 = 0;        // PWM1  DUTY CYCLE       P1.6       Red
    TA1CCR1 = 0;        // PWM1  DUTY CYCLE       P2.1       Green
    TA1CCR2 = 0;          // PWM3 DUTY CYCLE        P2.5       Blue

//
//Harici Kesme Configurasyonu P1.3 input select
//

    P1DIR &= ~BIT7; // P1.7 BUTTON INPUT
    P1SEL &= ~BIT7;
    P1SEL2 &= ~BIT7;
    P1REN |= BIT7; // pull up /pull down aktif
    P1OUT |= BIT7; // pull UP direnci aktif

    P1IES |= BUTTON;  // P1.7 Düþen Kenar olduðunda harici kesmeye girer
    P1IE = BUTTON;  //interrupt enables for P1.3
    P1IFG &= ~BIT7;

    //
    //UART CONFÝGURATÝON
    //

    P1SEL |= BIT1 + BIT2;  // P1.1/P1.2 rx/tx olarak kullanmak için yapýlan ayar
    P1SEL2 |= BIT1 + BIT2;
    UCA0CTL1 |= UCSSEL_2;   //SMCLK   iþlemciden gelen clocku aldý
    UCA0BR0 = 8;
    UCA0MCTL |= UCBRS2 + UCBRS1; // hata payýný gýdermek ýcýn modulasyon katsayýsý
    UCA0CTL1 &= ~UCSWRST;       //aktif etti
    IE2 |= UCA0RXIE;   // interrupt aktif etti

//
//ADC Configuration
//

    ADC10CTL0 &= ~ENC;
    ADC10AE0 |= BIT3;                         // PA.3 ADC option select input
    ADC10CTL0 = ADC10SHT_3 + ADC10ON + ADC10IE; // ADC 64 ornekleme süresi ,ADC10ON, interrupt enabled,
    ADC10CTL1 = INCH_3;                       // ADC10 input Channel Select Bit3
    ADC10CTL0 &= ~ADC10IFG;
    ADC10CTL0 |= ENC + ADC10SC;             //Sampling and conversion start

    __enable_interrupt();



    while (1)
    {
        Task_manager();
    }
}

//Timer ISR
#pragma vector = TIMER0_A0_VECTOR
__interrupt void Timer_A_CCR0_ISR(void)
{

    ++Timer_50ms_Counter;
    ++Timer_100ms_Counter;
    ++Timer_1s_Counter;
    ++Timer_2s_Counter;
    ++Timer_3s_Counter;

    if (Timer_50ms_Counter == 195)
    {
        Timer_50ms_flag = 1;
        Timer_50ms_Counter = 0;
    }
    if (Timer_100ms_Counter == 390)
    {
        Timer_100ms_flag = 1;
        Timer_100ms_Counter = 0;
    }
    if (Timer_1s_Counter == 3900)
    {
        Timer_1s_flag = 1;
        Timer_1s_Counter = 0;
    }
    if (Timer_2s_Counter == 7800)
    {
        Timer_2s_flag = 1;
        Timer_2s_Counter = 0;
    }
    if (Timer_3s_Counter == 11700)
    {
        Timer_3s_flag = 1;
        Timer_3s_Counter = 0;
    }

    TA0CTL &= ~TAIFG;
}

#pragma vector=ADC10_VECTOR
__interrupt void ADC10_ISR(void)
{
    ADC10CTL0 &= ~ENC;
    adc_val = ADC10MEM;
    ADC10CTL0 &= ~ADC10IFG;
    ADC10CTL0 |= ENC;             // Sampling and conversion start
    ADC10CTL0 |= ADC10SC;
}

#pragma vector=PORT1_VECTOR
__interrupt void Port_1(void)
{
    UCA0TXBUF = 1;
    P1OUT ^= BIT0;
    P1IFG &= ~BIT7;
}

#pragma vector = USCIAB0RX_VECTOR
interrupt void USCI0RX_ISR(void)
{
    receivedVal = UCA0RXBUF;
}

void Task_manager(void)
{
    if (receivedVal >= 2 && receivedVal < 5)
    {
        Mode1_Control();
    }
    if (receivedVal >= 5 && receivedVal < 8)
    {
        Mode2_Control();
    }
    if (receivedVal >= 11 && receivedVal < 256)
    {
        Mode3_Control();
    }
    if (receivedVal >= 8 && receivedVal < 11)
    {
        Mode4_Control();
    }
}



void Mode1_Control(void)
{
    while (receivedVal == 2)
    {
        TA0CCR1 = 0;              //         Red
        TA1CCR1 = 0;              //         Green
        TA1CCR2 = 0;              //         Blue
        Timer_delay_1s();
        TA0CCR1 = 255;              //         Red
        TA1CCR1 = 0;            //           Green
        TA1CCR2 = 0;              //           Blue

        Timer_delay_1s();

    }
    while (receivedVal == 3)
    {
        TA0CCR1 = 0;              //         Red
        TA1CCR1 = 0;             //           Green
        TA1CCR2 = 0;           //           Blue
        Timer_delay_2s();
        TA0CCR1 = 0;              //         Red
        TA1CCR1 = 255;             //           Green
        TA1CCR2 = 0;           //           Blue
        Timer_delay_2s();

    }
    while (receivedVal == 4)
    {
        TA0CCR1 = 0;              //         Red
        TA1CCR1 = 0;             //           Green
        TA1CCR2 = 0;           //           Blue
        Timer_delay_3s();
        TA0CCR1 = 0;              //         Red
        TA1CCR1 = 0;             //           Green
        TA1CCR2 = 255;           //           Blue
        Timer_delay_3s();

    }
}

void Mode2_Control(void)
{
    if (receivedVal == 5)
    {

        if (adc_val <= 400)
        {
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;        //         Green
            TA1CCR2 = 0;        //         Blue
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
        }

        if (adc_val > 400 && adc_val <= 500)
        {
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;        //         Green
            TA1CCR2 = 0;        //         Blue
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
        }
        if (adc_val > 500)
        {
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;        //         Green
            TA1CCR2 = 0;        //         Blue
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
        }
    }

    if (receivedVal == 6)
    {

        if (adc_val <= 400)
        {
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;        //         Green
            TA1CCR2 = 0;        //         Blue
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_50ms();
            Timer_delay_50ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
        }

        if (adc_val > 400 && adc_val <= 500)
        {
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;        //         Green
            TA1CCR2 = 0;        //         Blue
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
        }
        if (adc_val > 500)
        {
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;        //         Green
            TA1CCR2 = 0;        //         Blue
            Timer_delay_100ms();
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
        }

    }

    if (receivedVal == 7)
    {
        if (adc_val <= 400)
        {
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;        //         Green
            TA1CCR2 = 0;        //         Blue
            Timer_delay_100ms();
            Timer_delay_50ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_50ms();
            TA0CCR1 = 0;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
        }

        if (adc_val > 400 && adc_val <= 500)
        {
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;        //         Green
            TA1CCR2 = 0;        //         Blue
            Timer_delay_100ms();
            Timer_delay_50ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
            Timer_delay_50ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 255;
            TA1CCR2 = 0;
        }
        if (adc_val > 500)
        {
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;        //         Green
            TA1CCR2 = 0;        //         Blue
            Timer_delay_100ms();
            Timer_delay_50ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
            Timer_delay_100ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
            Timer_delay_50ms();
            TA0CCR1 = 255;              //         Red
            TA1CCR1 = 0;
            TA1CCR2 = 0;
        }
    }
}

void Mode3_Control(void)
{
    if (receivedVal >= 11 && receivedVal <= 92)
    {
        R_Value = (receivedVal - 11) * 3;
    }
    if (receivedVal >= 93 && receivedVal <= 174)
    {
        G_Value = (receivedVal - 93) * 3;
    }
    if (receivedVal >= 175 && receivedVal <= 256)
    {
        B_Value = (receivedVal - 175) * 3;
    }

    TA0CCR1 = R_Value;              //         Red
    TA1CCR1 = G_Value;          // PWM2 DUTY CYCLE          Green
    TA1CCR2 = B_Value;            // PWM3 DUTY CYCLE          Blue
}

void Mode4_Control(void)
{
    switch (receivedVal)
    {
    case 8:
        TA0CCR1 = 255;              //         Red
        TA1CCR1 = 0;
        TA1CCR2 = 0;
        break;
    case 9:        //Green
        TA0CCR1 = 0;              //         Red
        TA1CCR1 = 255;
        TA1CCR2 = 0;
        break;
    case 10:        //Blue
        TA0CCR1 = 0;              //         Red
        TA1CCR1 = 0;
        TA1CCR2 = 255;
        break;
    }
}

void Timer_delay_1s(void)
{
    while (Timer_1s_flag == 0)
        ;

    Timer_1s_flag = 0;
}

void Timer_delay_2s(void)
{
    while (Timer_2s_flag == 0)
        ;
    Timer_2s_flag = 0;
}

void Timer_delay_3s(void)
{
    while (Timer_3s_flag == 0)
        ;
    Timer_3s_flag = 0;
}

void Timer_delay_100ms(void)
{
    while (Timer_100ms_flag == 0)
        ;
    Timer_100ms_flag = 0;
}

void Timer_delay_50ms(void)
{
    while (Timer_50ms_flag == 0)
        ;
    Timer_50ms_flag = 0;
}
