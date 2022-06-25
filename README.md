# GitConfigSwitch
![Language badge](https://i.imgur.com/LUHwEU7.png)ㅤ![OS badge](https://i.imgur.com/MbF1zsp.png)ㅤ![State badge](https://imgur.com/G4YiiaG.png)

## 개요
여러 .gitconfig 파일을 switch해주는 유틸리티 소프트웨어입니다.

## 사용법
### Step 1. (프로파일 세팅)
> 아래와 같이 여러 .gitconfig 프로파일을 배치합니다.
> - %userprofile%/.gitconfig@UserA
> ```
>  [user]
>   name = UserA  
>   email = user_a@gmail.com
>  ```
> - %userprofile%/.gitconfig@UserB
> ```
>  [user]
>   name = UserB  
>   email = user_b@gmail.com
>  ```


### Step 2. (프로파일 전환)
> `GitConfigSwitch`를 실행하면 배치한 프로파일이 리스트로 출력됩니다.   
> 사용할 프로파일을 타이핑 후 <kbd>Enter</kbd>를 입력합니다.
>  
>  그러면 아래와 같이 출력되며 스위칭이 완료됩니다.
>  ```
>  Switching to '{Profile}' completed.
>  ```
