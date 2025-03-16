function GetRandomPosition()
    return Vector2(GenerateRandomNumber(-9, 9), 
                   GenerateRandomNumber(-5, 5))
end

function SetRandomTargetWhenReached()
    if(TargetReached()) then
        SetTarget(GetRandomPosition())
    end
end

SetRandomTargetWhenReached()