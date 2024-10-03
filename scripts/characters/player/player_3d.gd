extends CharacterBody3D


const SPEED = 5.0
const JUMP_VELOCITY = 4.5
const TURN_SPEED = 0.05

@onready var characterBody: CharacterBody3D = $"."
@onready var animateChar: AnimationPlayer = $"./corgi_proto/AnimationPlayer"

@export var playerCamera : Camera3D

func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta

	# Handle jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = JUMP_VELOCITY

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var input_dir := Input.get_vector("ui_left", "ui_right", "ui_down", "ui_up")
	var direction := (transform.basis * Vector3(input_dir.x, 0, input_dir.y)).normalized()
	
	if direction:
		velocity.x = direction.x * SPEED
		velocity.z = direction.z * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		velocity.z = move_toward(velocity.z, 0, SPEED)

	if(velocity.length() > 0.2):
		if(animateChar.current_animation != "Walk"):
			animateChar.play("Walk")
	else:
		animateChar.play("idle")
			
	if Input.is_action_pressed("ui_left"):
		self.rotate_y(TURN_SPEED)
	if Input.is_action_pressed("ui_right"):
		self.rotate_y(-TURN_SPEED)
	
	if Input.is_action_pressed("mouse_right_click"):
		playerCamera.rotate_y(TURN_SPEED)
		playerCamera.look_at(characterBody.position)
			
	print(velocity)
	move_and_slide()
